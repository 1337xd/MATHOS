import './App.css';
import React from "react";
import {useState} from 'react';
import "./index.css";

function App() {
  
    const [values, setValues] = useState({
    
  })


  const [submitted, setSubmitted] = useState(true);

  const handleFirstNameInputChange = (event) => {
    setValues({...values, firstName: event.target.value})
  }

  const handleLastNameInputChange = (event) => {
    setValues({...values, lastName: event.target.value})
  }
  
  const handleEmailInputChange = (event) => {
    setValues({...values, email: event.target.value})
  }

  const handleSubmit = (event) => {
    event.preventDefault();
    setSubmitted(true);
    console.log(values);
  }
  
  return (
    <div className="form-container">


      <form className="register-form" onSubmit={handleSubmit}>
        {submitted ? <div className="success-message">Sucessfully registered</div> : null}
        <input
        onChange={handleFirstNameInputChange}
        value={values.firstName}
          id="first-name"
          className="form-field"
          type="text"
          placeholder="First Name"
          name="firstName" />
          {submitted && values.firstName ? <span>enter first name</span> : null}
        
        <input
        onChange={handleLastNameInputChange}
        value={values.lastName}
          id="last-name"
          className="form-field"
          type="text"
          placeholder="Last Name"
          name="lastName" />
          {submitted && values.lastName ? <span>enter last name</span> : null}
        
        <input
        onChange={handleEmailInputChange}
        value={values.email}
          id="email"
          className="form-field"
          type="text"
          placeholder="Email"
          name="email" />
          {submitted && values.email ? <span>enter email</span> : null}
        
        <button className="form-field" type="submit">
          Register
        </button>
      </form>  
    </div>
  );
}
export default App;