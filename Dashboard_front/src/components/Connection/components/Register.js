import React, { Component } from 'react';
import axios from 'axios';
import {
  Form,
  Col,
  FormControl,
  ControlLabel,
  FormGroup,
  Button,
} from 'react-bootstrap';

export default class Register extends Component {
	constructor(props) {
		super(props);
	
		this.state = {
            username: "",
            email: "",
            password: "",
            password2: "",
		};
    }
	
      onUpdateInput(e, name) {
		this.setState({
			...this.state,
			[name]: e.target.value,
		});
	}

	async onSubmit(e) {
		e.preventDefault();

		const { username, email, password, password2 } = this.state;

		if ( !username || !email || !password || !password2)
			return;

		if (password !== password2)
			return;
			const name=username;
			
			const options = {
				method: 'POST',
				url: '/api/user',
				data: {
					name,
					password,
				}
		}
		const res = await axios(options);

		console.log(res.status)
	}

	render() {
		return (
			<Form
				horizontal
				onSubmit={ this.onSubmit.bind(this) }
				className="login-form"
			>
				<Col componentClass={ControlLabel} sm={2}>
					Username
				</Col>
				<Col sm={10}>
					<FormControl
						type="text"
						label="Username"
						placeholder="Username"
						value={ this.state.username }
						onChange={ e => this.onUpdateInput.bind(this)(e, 'username') }
					/>
				</Col>

				<Col componentClass={ControlLabel} sm={2}>
					Email
				</Col>
				<Col sm={10}>
					<FormControl
						type="email"
						label="Email"
						placeholder="Email"
						value={ this.state.email }
						onChange={ e => this.onUpdateInput.bind(this)(e, 'email') }
					/>
				</Col>

				<Col componentClass={ControlLabel} sm={2}>
					Password
				</Col>
				<Col sm={10}>
					<FormControl
						type="password"
						label="Password"
						placeholder="Password"
						value={ this.state.password }
						onChange={ e => this.onUpdateInput.bind(this)(e, 'password') }
					/>
				</Col>


				<Col componentClass={ControlLabel} sm={2}>
					Password Confirmation
				</Col>
				<Col sm={10}>
					<FormControl
						type="password"
						label="Password confirmation"
						placeholder="Password confirmation"
						value={ this.state.password2 }
						onChange={ e => this.onUpdateInput.bind(this)(e, 'password2') }
					/>
				</Col>

				<FormGroup>
					<Col smOffset={2} sm={10}>
						<Button type="submit">Register</Button>
					</Col>
				</FormGroup>
			</Form>
		);
	}
}