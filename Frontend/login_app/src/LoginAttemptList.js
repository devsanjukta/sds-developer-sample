import React, { useState } from "react";
import "./LoginAttemptList.css";

const LoginAttempt = (props) => <li {...props}>{props.children}</li>;

const LoginAttemptList = ({ attempts }) => {
  const [filter, setFilter] = useState("");

  // Filter attempts by login name containing the filter string (case insensitive)
  const filteredAttempts = attempts.filter(
    (attempt) =>
      attempt.login &&
      attempt.login.toLowerCase().includes(filter.toLowerCase())
  );

  return (
    <div className="Attempt-List-Main">
      <p>Recent activity</p>
      <input
        type="text"
        placeholder="Filter by login name..."
        value={filter}
        onChange={(e) => setFilter(e.target.value)}
      />
      <ul className="Attempt-List">
        {filteredAttempts.length === 0 && <li>No matching attempts.</li>}
        {filteredAttempts.map((attempt, index) => (
          <LoginAttempt key={index}>
            <strong>{attempt.login}</strong> at {attempt.time}
          </LoginAttempt>
        ))}
      </ul>
    </div>
  );
};

/*
const LoginAttemptList = (props) => (
	<div className="Attempt-List-Main">
	 	<p>Recent activity</p>
	  	<input type="input" placeholder="Filter..." />
		<ul className="Attempt-List">
			<LoginAttempt>TODO</LoginAttempt>
		</ul>
	</div>
);
*/

export default LoginAttemptList;