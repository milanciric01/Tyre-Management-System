import { Box, Button, Container, Grid, Paper, TextField, Typography } from "@mui/material";
import axios from "axios";
import { useState } from "react";
import Link from "@mui/material/Link";
import { Navigate, useNavigate } from 'react-router-dom';
import { jwtDecode } from "jwt-decode";

const Login = () => {
    const [username, setUsername] = useState(''); 
    const [password, setPassword] = useState(''); 
    const navigate = useNavigate();

    const loginHandler = (event) => {
        event.preventDefault();
        
        axios.post(`https://localhost:44386/api/authentification/login`, {
            username: username, 
            password: password 
        })
        .then((response) => {
            const token = response.data.token;
            localStorage.setItem('token', token);
            localStorage.setItem('id', response.data.userId);
            
            // Decode token to extract the role
            const decodedToken = jwtDecode(token);
            const role = decodedToken["http://schemas.microsoft.com/ws/2008/06/identity/claims/role"];
            localStorage.setItem('role', role);
            
            // Navigate based on role
            if (role === 'QualitySupervisor') {
                navigate('/QualitySupervisor');
            } else if (role === 'ProductionOperator') {
                navigate('/ProductionOperator');
            } else if (role === 'BusinessUnitLeader') {
                navigate('/BusinessUnitLeader');
            } else {
                console.error('Unexpected role:', role);
            }
        })
        .catch((error) => {
            localStorage.removeItem('token');
            localStorage.removeItem('id');
            localStorage.removeItem('role');
            if (error.response) {
                console.log("Response data:", error.response.data);
                console.log("Response status:", error.response.status);
            } else if (error.request) {
                console.log("Request made but no response received:", error.request);
            } else {
                console.log("Error:", error.message);
            }
        });
    }

    

    const usernameHandler = (event) => {
        const newUsername = event.target.value;
        setUsername(newUsername);
    }

    const passwordHandler = (event) => {
        const newPassword = event.target.value;
        setPassword(newPassword);
    }

    return (
        <>
            <Grid
                container
                spacing={0}
                direction="column"
                alignItems="center"
                justifyContent="center"
                style={{ minHeight: '100vh' }}
            >
                <Container component="main" maxWidth="xs" alignItems="center" justifyContent="center">
                    <Paper elevation={24}>
                        <Box
                            sx={{
                                marginTop: 8,
                                display: "flex",
                                flexDirection: "column",
                                alignItems: "center",
                            }}
                        >
                            <Typography component="h1" variant="h3">
                                LogIn
                            </Typography>
                            <Box component="form" noValidate sx={{ mt: 1 }}>
                                <TextField
                                    margin="normal"
                                    required
                                    fullWidth
                                    id="username"
                                    label="Username"
                                    name="username" 
                                    autoComplete="username"
                                    autoFocus
                                    onChange={usernameHandler}
                                />
                                <TextField
                                    margin="normal"
                                    required
                                    fullWidth
                                    name="password"
                                    label="Password"
                                    type="password"
                                    id="password"
                                    autoComplete="current-password"
                                    onChange={passwordHandler}
                                />
                                <Button
                                    type="submit"
                                    fullWidth
                                    variant="contained"
                                    sx={{ mt: 3, mb: 2 }}
                                    onClick={loginHandler}
                                >
                                    LogIn
                                </Button>
                                <Grid container sx={{ mt: 5, mb: 5 }}
                                    justifyContent="center"
                                    alignItems="center">
                                  
                                      
                                    
                                </Grid>
                            </Box>
                        </Box>
                    </Paper>
                </Container>
            </Grid>
        </>
    );
}

export default Login;
