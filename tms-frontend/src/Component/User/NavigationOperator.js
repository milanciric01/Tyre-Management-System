import { BottomNavigation, BottomNavigationAction } from "@mui/material";
import { useNavigate } from "react-router-dom";
import LogoutIcon from '@mui/icons-material/Logout';

const NavigationOperator = () => {
    const navigate = useNavigate();
    const logoutHandler = (event) => {
        event.preventDefault();
        localStorage.removeItem('id');
        localStorage.removeItem('token');
        navigate('/');
    };
    return (
        <>
            <BottomNavigation 
                showLabels
                sx={{ marginLeft: '0px', backgroundColor: '#e1f7f4' }}
            >
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

export default NavigationOperator;
