import React, { useState } from "react";
import './App.css';
import LoginForm from './LoginForm';
import LoginAttemptList from './LoginAttemptList';

const App = () => {
  const [loginAttempts, setLoginAttempts] = useState([]);

  const handleLoginSubmit = ({ login, password }) => {
    // Add new attempt with timestamp
    const newAttempt = { login, password, time: new Date().toLocaleString() };

    // Update state with new attempt appended
    setLoginAttempts([...loginAttempts, newAttempt]);

    console.log("New login attempt:", newAttempt);
  };

  return (
    <div className="App">
      <LoginForm onSubmit={handleLoginSubmit} />
      <LoginAttemptList attempts={loginAttempts} />
    </div>
  );
};

export default App;
