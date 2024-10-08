import { useEffect, useState } from 'react'
import './App.css'
import axios from 'axios';
import { Header, List } from 'semantic-ui-react';
import logo from './logo.svg';

function App() {
  const [activities, setActivities] =  useState([]);

  // use Effect has parameter called deps , if present effect will onyl activate in the values in the list changes
  useEffect(() => {
    axios.get('http://localhost:5000/api/activities')
      .then(response => {
        setActivities(response.data)      
      })
  }, []) //empty array --> inside the use effect will execute once 

  
  return (
    <div>
      {/* <Header as='h2' icon='users' content='Reactivities'/> */}
      {/* <h1>Reactivities</h1> */}
      <Header as = 'h2' icon='users' content= 'Reactivities'></Header>
      <List>
        {activities.map((activity : any) => (
          <li key = {activity.id}>  
            {activity.title}
          </li>
        ))}
      </List>
    </div>
      
  )
}

export default App
  