import logo from './logo.svg';
import './App.css';
import { GetTrainRoutes } from './services/TrainRouteService';
import { useEffect, useState } from 'react';

function App() {
  const [routes, setRoutes] = useState([]);
  const [currentTime, setCurrentTime] = useState(Date().toLocaleString());
  
  useEffect(() => {
    async function loadData() {
      let routes = await GetTrainRoutes();
      setRoutes(routes);
    }

    setInterval(() => {
      setCurrentTime(Date().toLocaleString());
    }, 1000)

    setInterval(() => {
      loadData();
    }, 5000)
  }, []);

  return (
    <div className="App">
      {currentTime}
      <table>
        <thead>
          <tr>
            <th>Start</th>
            <th>End</th>
            <th>Cost</th>
            <th>Distance</th>
          </tr>
        </thead>
      {routes.map((element, index) => 
        <tr id={index}>
          <td>{element.start}</td>
          <td>{element.end}</td>
          <td>{element.cost}</td>
          <td>{element.distanceInKm}</td>
        </tr>
      )}    
      </table>  
    </div>
  );
}



export default App;
