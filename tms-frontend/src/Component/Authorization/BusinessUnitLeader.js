import React, { useState, useEffect } from 'react';
import { Container, Typography, Paper, Table, TableHead, TableRow, TableCell, TableBody, Box } from '@mui/material';
import axios from 'axios';
import NavigationLeader from '../User/NavigationLeader';

const BusinessUnitLeader = () => {
  const [productionByDay, setProductionByDay] = useState([]);
  const [productionByShift, setProductionByShift] = useState([]);
  const [productionByMachine, setProductionByMachine] = useState([]);
  const [productionByOperator, setProductionByOperator] = useState([]);
  const [stockBalance, setStockBalance] = useState([]);

  useEffect(() => {
    axios.get('https://localhost:44386/api/bussines-unit/production-reports-day')
      .then(response => setProductionByDay(response.data.$values || []))
      .catch(error => console.log("Error fetching production by day:", error));
  }, []);

  useEffect(() => {
    axios.get('https://localhost:44386/api/bussines-unit/production-reports-shift')
      .then(response => setProductionByShift(response.data.$values || []))
      .catch(error => console.log("Error fetching production by shift:", error));
  }, []);

  useEffect(() => {
    axios.get('https://localhost:44386/api/bussines-unit/production-reports-machine')
      .then(response => setProductionByMachine(response.data.$values || []))
      .catch(error => console.log("Error fetching production by machine:", error));
  }, []);

  useEffect(() => {
    axios.get('https://localhost:44386/api/bussines-unit/production-reports-operator')
      .then(response => setProductionByOperator(response.data.$values || []))
      .catch(error => console.log("Error fetching production by operator:", error));
  }, []);

  useEffect(() => {
    axios.get('https://localhost:44386/api/bussines-unit/production-reports-stockbalance')
      .then(response => setStockBalance(response.data.$values || []))
      .catch(error => console.log("Error fetching stock balance:", error));
  }, []);

  return (
    <Container component="main" maxWidth="lg">
      <NavigationLeader />
      <Typography variant="h4" align="center" gutterBottom>
        Production Summary
      </Typography>

      {/* Common Styles for Tables */}
      <Box display="flex" flexDirection="column" gap={2}>
        <Paper elevation={6} sx={{ padding: 4 }}>
          <Typography variant="h6">Production By Day</Typography>
          <Table>
            <TableHead>
              <TableRow>
                <TableCell sx={{ width: '50%' }}>Date</TableCell>
                <TableCell sx={{ width: '50%' }}>Quantity</TableCell>
              </TableRow>
            </TableHead>
            <TableBody>
              {productionByDay.map((record) => (
                <TableRow key={record.$id}>
                  <TableCell>{new Date(record.productionDate).toLocaleDateString()}</TableCell>
                  <TableCell>{record.totalProduction}</TableCell>
                </TableRow>
              ))}
            </TableBody>
          </Table>
        </Paper>

        <Paper elevation={6} sx={{ padding: 4 }}>
          <Typography variant="h6">Production By Shift</Typography>
          <Table>
            <TableHead>
              <TableRow>
                <TableCell sx={{ width: '50%' }}>Shift</TableCell>
                <TableCell sx={{ width: '50%' }}>Quantity</TableCell>
              </TableRow>
            </TableHead>
            <TableBody>
              {productionByShift.map((record) => (
                <TableRow key={record.$id}>
                  <TableCell>{record.productionShift}</TableCell>
                  <TableCell>{record.totalProduction}</TableCell>
                </TableRow>
              ))}
            </TableBody>
          </Table>
        </Paper>

        <Paper elevation={6} sx={{ padding: 4 }}>
          <Typography variant="h6">Production By Machine</Typography>
          <Table>
            <TableHead>
              <TableRow>
                <TableCell sx={{ width: '50%' }}>Machine</TableCell>
                <TableCell sx={{ width: '50%' }}>Quantity</TableCell>
              </TableRow>
            </TableHead>
            <TableBody>
              {productionByMachine.map((record) => (
                <TableRow key={record.$id}>
                  <TableCell>{record.machineNumber}</TableCell>
                  <TableCell>{record.totalProduction}</TableCell>
                </TableRow>
              ))}
            </TableBody>
          </Table>
        </Paper>

        <Paper elevation={6} sx={{ padding: 4 }}>
          <Typography variant="h6">Production By Operator</Typography>
          <Table>
            <TableHead>
              <TableRow>
                <TableCell sx={{ width: '50%' }}>Operator</TableCell>
                <TableCell sx={{ width: '50%' }}>Quantity</TableCell>
              </TableRow>
            </TableHead>
            <TableBody>
              {productionByOperator.map((record) => (
                <TableRow key={record.$id}>
                  <TableCell>{record.operatorName}</TableCell>
                  <TableCell>{record.totalProduction}</TableCell>
                </TableRow>
              ))}
            </TableBody>
          </Table>
        </Paper>

        <Paper elevation={6} sx={{ padding: 4 }}>
          <Typography variant="h6">Stock Balance</Typography>
          <Table>
            <TableHead>
              <TableRow>
                <TableCell sx={{ width: '50%' }}>Tyre Code</TableCell>
                <TableCell sx={{ width: '50%' }}>Stock Quantity</TableCell>
              </TableRow>
            </TableHead>
            <TableBody>
              {stockBalance.map((stock) => (
                <TableRow key={stock.tyreCode}>
                  <TableCell>{stock.tyreCode}</TableCell>
                  <TableCell>{stock.totalStock}</TableCell>
                </TableRow>
              ))}
            </TableBody>
          </Table>
        </Paper>
      </Box>
    </Container>
  );
};

export default BusinessUnitLeader;
