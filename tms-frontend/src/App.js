import './App.css';
import LogIn from './Component/Authorization/LogIn';
import {BrowserRouter as Router, Route, Routes } from 'react-router-dom';
import ProductionOperator from './Component/Authorization/ProductionOperator';
import QualitySupervisor from './Component/Authorization/QualitySupervisor';
import BusinessUnitLeader from './Component/Authorization/BusinessUnitLeader';
function App() {
  return (
    <main className="App">
    <Router>
     <Routes>
       
      
       <Route path='/' element={<LogIn />} />
       <Route path='/ProductionOperator' element={<ProductionOperator />} />
       <Route path='/QualitySupervisor' element={<QualitySupervisor />} />
       <Route path='/BusinessUnitLeader' element={<BusinessUnitLeader />} />

     </Routes>
   </Router>
 </main>
  );
}
export default App;
