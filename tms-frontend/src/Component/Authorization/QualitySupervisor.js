import { Box, Button, Container, Grid, Paper, TextField, Typography, Table, TableHead, TableBody, TableCell, TableRow, TableSortLabel, Snackbar, Alert } from "@mui/material";
import MenuItem from '@mui/material/MenuItem';
import axios from "axios";
import { useState, useEffect } from "react";
import NavigationSupervisor from "../User/NavigationSupervisor";

const QualitySupervisor = () => {
    const [tyreName, setTyreName] = useState("");
    const [quantitySold, setQuantitySold] = useState(0);
    const [unitOfMeasure, setUnitOfMeasure] = useState("");
    const [price, setPrice] = useState(0);
    const [referenceProductionId, setReferenceProductionId] = useState("");
    const [destinationMarket, setDestinationMarket] = useState("");
    const [purchasingCompany, setPurchasingCompany] = useState("");
    const [history, setHistory] = useState([]);
    const [value, setValue] = useState(0);
    const [order, setOrder] = useState('asc');
    const [orderBy, setOrderBy] = useState('');
    const [openSnackbar, setOpenSnackbar] = useState(false);
    const [snackbarMessage, setSnackbarMessage] = useState("");
    const [snackbarSeverity, setSnackbarSeverity] = useState("success");

    const unitOptions = ["Pieces", "Kg", "Dozens"];
    const marketOptions = ["Local", "International"];

    // Premestite fetchHistory ovde
    const fetchHistory = async () => {
        try {
            const response = await axios.get("https://localhost:44386/api/supervisor/supervisor-history");
            if (response.data && response.data.$values) {
                setHistory(response.data.$values);
            } else {
                setHistory([]);  // Handle no data case
            }
        } catch (error) {
            console.log("Error fetching sales history:", error);
        }
    };

    // useEffect za učitavanje istorije prodaja
    useEffect(() => {
        fetchHistory();
    }, []);

    const submitHandler = async (event) => {
        event.preventDefault();
        const currentDate = new Date().toISOString().split('T')[0];
        try {
            await axios.post("https://localhost:44386/api/supervisor/register-sale", {
                tyreName,
                quantitySold,
                unitOfMeasure,
                price,
                dateOfSale: currentDate,
                referenceProductionId,
                destinationMarket,
                purchasingCompany,
            });
            setSnackbarMessage("Tyre sale successfully registered!");
            setSnackbarSeverity("success");
            setOpenSnackbar(true);
            
            // Ponovo učitaj istoriju nakon uspešne registracije
            fetchHistory();
        } catch (error) {
            setSnackbarMessage("Error in registration.");
            setSnackbarSeverity("error");
            setOpenSnackbar(true);
            console.log("Error in registration:", error);
        }
    };

    const handleSnackbarClose = (event, reason) => {
        if (reason === 'clickaway') {
            return;
        }
        setOpenSnackbar(false);
    };


    const handleSortRequest = (property) => {
        const isAsc = orderBy === property && order === 'asc';
        setOrder(isAsc ? 'desc' : 'asc');
        setOrderBy(property);
    };

    const sortedHistory = Array.isArray(history) ? [...history].sort((a, b) => {
        if (orderBy) {
            const valueA = a[orderBy];
            const valueB = b[orderBy];
            if (valueA < valueB) return order === 'asc' ? -1 : 1;
            if (valueA > valueB) return order === 'asc' ? 1 : -1;
            return 0;
        }
        return 0;
    }) : [];

    return (
        <>
            <NavigationSupervisor />
            {value === 0 && (
                <Grid container spacing={0} direction="column" alignItems="center" justifyContent="center" style={{ minHeight: '100vh' }}>
                    <Container component="main" maxWidth="md">
                        <Paper elevation={6} sx={{ padding: 4, marginTop: 4 }}>
                            <Typography component="h1" variant="h4" align="center">
                                Register Tyre Sale
                            </Typography>
                            <Box component="form" sx={{ mt: 3 }} onSubmit={submitHandler}>
                                <TextField
                                    margin="normal"
                                    fullWidth
                                    required
                                    label="Tyre Name"
                                    value={tyreName}
                                    onChange={(e) => setTyreName(e.target.value)}
                                />
                                <TextField
                                    margin="normal"
                                    fullWidth
                                    required
                                    label="Quantity Sold"
                                    type="number"
                                    value={quantitySold}
                                    onChange={(e) => setQuantitySold(e.target.value)}
                                />
                                <TextField
                                    select
                                    margin="normal"
                                    fullWidth
                                    required
                                    label="Unit of Measure"
                                    value={unitOfMeasure}
                                    onChange={(e) => setUnitOfMeasure(e.target.value)}
                                >
                                    {unitOptions.map((unit) => (
                                        <MenuItem key={unit} value={unit}>
                                            {unit}
                                        </MenuItem>
                                    ))}
                                </TextField>
                                <TextField
                                    margin="normal"
                                    fullWidth
                                    required
                                    label="Price per Unit"
                                    type="number"
                                    value={price}
                                    onChange={(e) => setPrice(e.target.value)}
                                />
                                <TextField
                                    margin="normal"
                                    fullWidth
                                    required
                                    label="Reference Production Order ID"
                                    value={referenceProductionId}
                                    onChange={(e) => setReferenceProductionId(e.target.value)}
                                />
                                <TextField
                                    select
                                    margin="normal"
                                    fullWidth
                                    required
                                    label="Destination Market"
                                    value={destinationMarket}
                                    onChange={(e) => setDestinationMarket(e.target.value)}
                                >
                                    {marketOptions.map((market) => (
                                        <MenuItem key={market} value={market}>
                                            {market}
                                        </MenuItem>
                                    ))}
                                </TextField>
                                <TextField
                                    margin="normal"
                                    fullWidth
                                    required
                                    label="Purchasing Company"
                                    value={purchasingCompany}
                                    onChange={(e) => setPurchasingCompany(e.target.value)}
                                />
                                <Button type="submit" variant="contained" color="primary" fullWidth sx={{ mt: 3 }}>
                                    Submit Tyre Sale
                                </Button>
                            </Box>
                        </Paper>

                        {/* Tabela za prikaz istorije prodaja */}
                        <Paper elevation={6} sx={{ padding: 4, marginTop: 4 }}>
                            <Typography component="h2" variant="h5">
                                Sales History
                            </Typography>
                            {history.length > 0 ? (
                                <Table>
                                    <TableHead>
                                        <TableRow>
                                            <TableCell>Tyre Name</TableCell>
                                            <TableCell>
                                                <TableSortLabel
                                                    active={orderBy === 'quantitySold'}
                                                    direction={orderBy === 'quantitySold' ? order : 'asc'}
                                                    onClick={() => handleSortRequest('quantitySold')}
                                                >
                                                    Quantity Sold
                                                </TableSortLabel>
                                            </TableCell>
                                            <TableCell>
                                                <TableSortLabel
                                                    active={orderBy === 'price'}
                                                    direction={orderBy === 'price' ? order : 'asc'}
                                                    onClick={() => handleSortRequest('price')}
                                                >
                                                    Price
                                                </TableSortLabel>
                                            </TableCell>
                                            <TableCell>
                                                <TableSortLabel
                                                    active={orderBy === 'dateOfSale'}
                                                    direction={orderBy === 'dateOfSale' ? order : 'asc'}
                                                    onClick={() => handleSortRequest('dateOfSale')}
                                                >
                                                    Date of Sale
                                                </TableSortLabel>
                                            </TableCell>
                                            <TableCell>Destination Market</TableCell>
                                            <TableCell>Purchasing Company</TableCell>
                                        </TableRow> 
                                    </TableHead>
                                    <TableBody>
                                        {sortedHistory.map((record) => (
                                            <TableRow key={record.id}>
                                                <TableCell>{record.tyreName}</TableCell>
                                                <TableCell>{record.quantitySold}</TableCell>
                                                <TableCell>{record.price}</TableCell>
                                                <TableCell>{new Date(record.dateOfSale).toLocaleDateString()}</TableCell>
                                                <TableCell>{record.destinationMarket}</TableCell>
                                                <TableCell>{record.purchasingCompany}</TableCell>
                                            </TableRow>
                                        ))}
                                    </TableBody>
                                </Table>
                            ) : (
                                <Typography>No records found.</Typography>
                            )}
                        </Paper>
                    </Container>
                </Grid>
            )}
            <Snackbar open={openSnackbar} autoHideDuration={6000} onClose={handleSnackbarClose} anchorOrigin={{ vertical: 'top', horizontal: 'center' }}>
                <Alert onClose={handleSnackbarClose} severity={snackbarSeverity} sx={{ width: '100%' }}>
                    {snackbarMessage}
                </Alert>
            </Snackbar>
        </>

        
    );
};

export default QualitySupervisor;
