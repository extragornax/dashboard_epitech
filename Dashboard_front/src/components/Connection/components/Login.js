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
			name: "",
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

		const { name, password } = this.state;

		if (!name || !password)
			return;
		const options = {
			method: 'POST',
			url: '/api/Session',
			data: {
				name,
				password,
			}
	}

		const res = await axios(options);
		/* A checker le retour de la requête */
		localStorage.setItem('token', res.data);
		this.props.push('/dashboard');
	}

	render() {
		return (
			<Form
				horizontal
				onSubmit={ this.onSubmit.bind(this) }
				className="login-form"
			>
				<Col componentClass={ControlLabel} sm={2}>
					Login
				</Col>
				<Col sm={10}>
					<FormControl
						type="text"
						label="text"
						placeholder="Login"
						value={ this.state.name }
						onChange={ e => this.onUpdateInput.bind(this)(e, 'name') }
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