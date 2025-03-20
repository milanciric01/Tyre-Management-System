import { BottomNavigation, BottomNavigationAction } from "@mui/material";
import { useNavigate, useLocation } from "react-router-dom";
import LogoutIcon from '@mui/icons-material/Logout';
import SupervisorAccountIcon from '@mui/icons-material/SupervisorAccount';
import BusinessCenterIcon from '@mui/icons-material/BusinessCenter';
import ReceiptIcon from '@mui/icons-material/Receipt'; // Ikona za Quality Supervisor

const NavigationSupervisor = () => {
    const navigate = useNavigate();
    const location = useLocation();

    const logoutHandler = (event) => {
        event.preventDefault();
        localStorage.removeItem('id');
        localStorage.removeItem('token');
        navigate('/');
    };

    const goToBusinessUnitLeader = () => {
        navigate('/BusinessUnitLeader');
    };

    const goToProductionOperator = () => {
        navigate('/ProductionOperator');
    };

    const goToQualitySupervisor = () => {
        navigate('/QualitySupervisor');
    };

    return (
        <>
            <BottomNavigation 
                showLabels
                sx={{ marginLeft: '0px', backgroundColor: '#e1f7f4' }}
            >
                
                {location.pathname !== '/quality-supervisor' && (
                    <BottomNavigationAction 
                        label="Quality Supervisor" 
                        icon={<ReceiptIcon />} 
                        sx={{ marginRight: '10px' }} 
                        onClick={goToQualitySupervisor}
                    />
                )}
                
                {location.pathname !== '/business-unit-leader' && (
                    <BottomNavigationAction 
                        label="Business Unit Leader" 
                        icon={<BusinessCenterIcon />} 
                        sx={{ marginRight: '10px' }} 
                        onClick={goToBusinessUnitLeader}
                    />
                )}
                
                {location.pathname !== '/production-operator' && (
                    <BottomNavigationAction 
                        label="Production Operator" 
                        icon={<SupervisorAccountIcon />} 
                        sx={{ marginRight: '10px' }} 
                        onClick={goToProductionOperator}
                    />
                )}
                <BottomNavigationAction 
                    label="Log out" 
                    icon={<LogoutIcon />} 
                    sx={{ marginRight: '10px' }} 
                    onClick={logoutHandler}
                />
            </BottomNavigation>
        </>
    );
};

export default NavigationSupervisor;
