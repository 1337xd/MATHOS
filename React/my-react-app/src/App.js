import './App.css';
import React from 'react';
import Header from './components/Header.js';
import Content from './components/Content.js';
import Tick from './components/Tick.js';
import Car from './components/Car.js';
import MyForms from './components/MyForms.js';



class App extends React.Component {
   render() {
      return (
         <div>
            <Header/>
            <Content/>
            <Tick/>
            <Car/>
            <MyForms/>
         </div>
      );
   }
}

export default App;