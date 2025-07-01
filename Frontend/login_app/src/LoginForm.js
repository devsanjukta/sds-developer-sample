import React, { useState } from "react";
import './LoginForm.css';

const LoginForm = (props) => {
	const [formData, setFormData] = useState({ login: "", password: "" });

	const handleChange = (e) => {
		const { id, value } = e.target;
		setFormData((prev) => ({
		...prev,
		[id]: value, // update the field based on input's id attribute
		}));
    };

	const handleSubmit = (event) => {
		event.preventDefault();

		props.onSubmit(formData);

		// Clear the form
		setFormData({ login: "", password: "" });
   };
	
   /*
	const handleSubmit = (event) =>{
		event.preventDefault();

		props.onSubmit({
			login: undefined,
			password: undefined,
		});
	}
	*/

	return (
		<form className="form" onSubmit={handleSubmit}>
			<h1>Login</h1>
			
			<label htmlFor="login">Name</label>
			<input
				type="text"
				id="login"
				value={formData.login}
				onChange={handleChange}
				required
			/>

			<label htmlFor="password">Password</label>
			<input
				type="password"
				id="password"
				value={formData.password}
				onChange={handleChange}
				required
			/>

      		<button type="submit">Continue</button>
		</form>
	)
}

export default LoginForm;