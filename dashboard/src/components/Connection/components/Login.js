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

export default class Login extends Component {
	constructor(props) {
		super(props);
	
		this.state = {
			email: "",
			password: "",
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

		const { email, password } = this.state;

		if (!email || !password)
			return;

		const options = {
			method: 'POST',
			url: 'http://requestbin.fullcontact.com/1jw34841',
			data: {
				email,
				password,
			}
	}

		const res = await axios(options);
		/* A checker le retour de la requête */
		localStorage.setItem('token', res.data);
		this.props.push('/');
	}

	render() {
		return (
			<Form
				horizontal
				onSubmit={ this.onSubmit.bind(this) }
				className="login-form"
			>
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
						label="password"
						placeholder="Password"
						value={ this.state.password }
						onChange={ e => this.onUpdateInput.bind(this)(e, 'password') }
					/>
				</Col>

				<FormGroup>
					<Col smOffset={2} sm={10}>
						<Button type="submit">Login</Button>
					</Col>
				</FormGroup>
			</Form>
		);
	}
}