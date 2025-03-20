import React, { useState, useEffect } from "react"; 
import { Box, Button, Container, Grid, MenuItem, Paper, TextField, Typography, Table, TableBody, TableCell, TableContainer, TableHead, TableRow, TableSortLabel, Snackbar, Alert } from "@mui/material";
import axios from "axios";
import NavigationOperator from "../User/NavigationOperator";

const ProductionOperator = () => {
  const [value, setValue] = useState(0);
  const [tyreCode, setTyreCode] = useState("");
  const [quantity, setQuantity] = useState(0);
  const [operatorId, setOperatorId] = useState(localStorage.getItem("id"));
  const [productionShift, setProductionShift] = useState("");
  const [machineNumber, setMachineNumber] = useState("");
  const [history, setHistory] = useState([]);
  const [orderDirection, setOrderDirection] = useState("asc");
  const [orderBy, setOrderBy] = useState("productionDate");
  const [isEditing, setIsEditing] = useState(false);
  const [currentRecord, setCurrentRecord] = useState(null);
  const [selectedMachine, setSelectedMachine] = useState(''); // or 'Machine 1', etc.
  
  
  const [openSnackbar, setOpenSnackbar] = useState(false);
  const [snackbarMessage, setSnackbarMessage] = useState("");
  const [snackbarSeverity, setSnackbarSeverity] = useState("success");

  useEffect(() => {
    fetchHistory();
  }, [operatorId]);

  const userId = localStorage.getItem("id");

  const fetchHistory = () => {
    let url = userId === '2' 
      ? 'https://localhost:44386/api/supervisor/all-history'
      : `https://localhost:44386/api/controller/history/${operatorId}`;
  
    axios
      .get(url)
      .then((response) => {
        if (response.data && response.data.$values) {
          setHistory(response.data.$values);
        } else {
          console.error("API response does not have $values:", response.data);
        }
      })
      .catch((error) => console.log("Error:", error));
  };

  const submitHandler = (event) => {
    event.preventDefault();
    console.log("Form submitted. isEditing:", isEditing);

    if (isEditing && currentRecord) {
      handleUpdate(currentRecord);
    } else {
      const currentDate = new Date();

      
      if (isNaN(currentDate)) {
        console.error("Invalid date value:", currentDate);
        handleSnackbarOpen("Invalid date value. Please check the input.", "error");
        return;
      }

      axios
        .post("https://localhost:44386/api/controller/createRecord", {
          tyreCode,
          quantity,
          productionShift,
          machineNumber,
          performedById: operatorId,
          productionDate: currentDate.toISOString(),
        })
        .then(() => {
          handleSnackbarOpen("Tyre production successfully registered!", "success");
          resetForm();
          fetchHistory();
        })
        .catch((error) => {
          console.log("Error in creating records", error);
          handleSnackbarOpen("Failed to register tyre production.", "error");
        });
    }
  };

  const resetForm = () => {
    setTyreCode("");
    setQuantity(0);
    setProductionShift("");
    setMachineNumber("");
    setIsEditing(false);
    setCurrentRecord(null);
  };

  const handleEdit = (record) => {
    console.log("Editing record:", record);
    setTyreCode(record.tyreCode);
    setQuantity(record.quantity);
    setProductionShift(record.productionShift);
    setMachineNumber(record.machineNumber);
    setIsEditing(true);
    setCurrentRecord(record);
  };

  const handleUpdate = (record) => {
    console.log("Updating record:", record); 
    if (!tyreCode || !quantity || !productionShift || !machineNumber) {
        handleSnackbarOpen("All fields are required.", "error");
        return;
    }
    console.log("Production Shift:", productionShift);

    const formData = new FormData();
    formData.append('Id', record.id);
    formData.append('TyreCode', tyreCode);
    formData.append('Quantity', quantity);
    formData.append('ProductionDate', new Date().toISOString());
    formData.append('ProductionShift', productionShift);
    formData.append('MachineNumber', machineNumber);
    formData.append('PerformedById', operatorId);

    axios
        .put(`https://localhost:44386/api/supervisor/update`, formData)
        .then(() => {
            handleSnackbarOpen("Record updated successfully!", "success");
            resetForm();
            fetchHistory();
        })
        .catch((error) => {
            console.log("Error in updating record:", error);
            if (error.response && error.response.data && error.response.data.errors) {
                const { errors } = error.response.data;
                console.log("Validation errors:", errors);

                if (errors.TyreCode) {
                    handleSnackbarOpen(`TyreCode error: ${errors.TyreCode[0]}`, "error");
                }
                if (errors.MachineNumber) {
                    handleSnackbarOpen(`MachineNumber error: ${errors.MachineNumber[0]}`, "error");
                }
                if (errors.ProductionShift) {
                    handleSnackbarOpen(`ProductionShift error: ${errors.ProductionShift[0]}`, "error");
                }
            } else {
                handleSnackbarOpen("Failed to update the record.", "error");
            }
        });
};

  const handleRequestSort = (property) => {
    const isAsc = orderBy === property && orderDirection === "asc";
    setOrderDirection(isAsc ? "desc" : "asc");
    setOrderBy(property);
  };

  const sortedHistory = Array.isArray(history) ? [...history].sort((a, b) => {
    if (orderBy === "productionDate") {
      return orderDirection === "asc"
        ? new Date(a.productionDate) - new Date(b.productionDate)
        : new Date(b.productionDate) - new Date(a.productionDate);
    }
    if (orderBy === "quantity") {
      return orderDirection === "asc" ? a.quantity - b.quantity : b.quantity - a.quantity;
    }
    return 0;
  }) : [];

  
  const handleSnackbarOpen = (message, severity) => {
    setSnackbarMessage(message);
    setSnackbarSeverity(severity);
    setOpenSnackbar(true);
  };

  const handleSnackbarClose = () => {
    setOpenSnackbar(false);
  };

  return (
    <>
      <NavigationOperator />
      {value === 0 && (
        <Grid container spacing={0} direction="column" alignItems="center" justifyContent="center" style={{ minHeight: '100vh' }}>
          <Container component="main" maxWidth="md">
            <Paper elevation={6} sx={{ padding: 4, marginTop: 4 }}>
              <Typography component="h1" variant="h4" align="center">
                Register Tyre Production
              </Typography>
              <Box component="form" sx={{ mt: 3 }} onSubmit={submitHandler}>
                <TextField
                  margin="normal"
                  fullWidth
                  required
                  label="Tyre Code"
                  value={tyreCode}
                  onChange={(e) => setTyreCode(e.target.value)}
                />
                <TextField
                  margin="normal"
                  fullWidth
                  required
                  label="Quantity"
                  type="number"
                  value={quantity}
                  onChange={(e) => setQuantity(e.target.value)}
                />
                <TextField
                  select
                  margin="normal"
                  fullWidth
                  required
                  label="Production Shift"
                  value={productionShift}
                  onChange={(e) => setProductionShift(e.target.value)}
                >
                  {["Morning", "Afternoon", "Night"].map((shift) => (
                    <MenuItem key={shift} value={shift}>
                      {shift}
                    </MenuItem>
                  ))}
                </TextField>
                <TextField
                  select
                  margin="normal"
                  fullWidth
                  required
                  label="Machine Number"
                  value={machineNumber}
                  onChange={(e) => setMachineNumber(e.target.value)}
                >
                  {["Machine 1", "Machine 2", "Machine 3"].map((machine) => (
                    <MenuItem key={machine} value={machine}>
                      {machine}
                    </MenuItem>
                  ))}
                </TextField>
                <Button type="submit" variant="contained" color="primary" fullWidth sx={{ mt: 3 }}>
                  {isEditing ? "Update Production Record" : "Submit Production Record"}
                </Button>
              </Box>
            </Paper>

            <Paper elevation={6} sx={{ padding: 4, marginTop: 4 }}>
              <Typography component="h2" variant="h5">
                My Production History
              </Typography>
              <TableContainer>
                <Table>
                  <TableHead>
                    <TableRow>
                      <TableCell>
                        <TableSortLabel
                          active={orderBy === "productionDate"}
                          direction={orderBy === "productionDate" ? orderDirection : "asc"}
                          onClick={() => handleRequestSort("productionDate")}
                        >
                          Time
                        </TableSortLabel>
                      </TableCell>
                      <TableCell>Tyre Code</TableCell>
                      <TableCell>
                        <TableSortLabel
                          active={orderBy === "quantity"}
                          direction={orderBy === "quantity" ? orderDirection : "asc"}
                          onClick={() => handleRequestSort("quantity")}
                        >
                          Quantity
                        </TableSortLabel>
                      </TableCell>
                      <TableCell>Shift</TableCell>
                      <TableCell>Machine</TableCell>
                      {userId === '2' && (
                        <TableCell>Edit</TableCell>
                      )}
                    </TableRow>
                  </TableHead>
                  <TableBody>
                    {sortedHistory.length > 0 ? (
                      sortedHistory.map((record) => (
                        <TableRow key={record.id}>
                          <TableCell>{new Date(record.productionDate).toLocaleString()}</TableCell>
                          <TableCell>{record.tyreCode}</TableCell>
                          <TableCell>{record.quantity}</TableCell>
                          <TableCell>{record.productionShift}</TableCell>
                          <TableCell>{record.machineNumber}</TableCell>
                          {userId === '2' && (
                            <TableCell>
                              <Button onClick={() => handleEdit(record)}>Edit</Button>
                            </TableCell>
                          )}
                        </TableRow>
                      ))
                    ) : (
                      <TableRow>
                        <TableCell colSpan={6} align="center">No production records found.</TableCell>
                      </TableRow>
                    )}
                  </TableBody>
                </Table>
              </TableContainer>
            </Paper>
          </Container>
        </Grid>
      )}
      <Snackbar
                open={openSnackbar}
                autoHideDuration={6000}
                onClose={handleSnackbarClose}
                anchorOrigin={{ vertical: 'top', horizontal: 'center' }}
            >
                <Alert onClose={handleSnackbarClose} severity={snackbarSeverity} sx={{ width: '100%' }}>
                    {snackbarMessage}
                </Alert>
            </Snackbar>
      
    </>
  );
};

export default ProductionOperator;
