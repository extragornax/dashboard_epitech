import React, { Component } from 'react';
import { Login, Register } from './components';
import { Tabs, Tab } from 'react-bootstrap';
import './Connection.css';

export default class Connection extends Component {
    render() {
        return (
            <div
            className="connection-tabs"
            >
				<h1>Welcome to the Epitech Dashboard</h1>
                <Tabs
                    defaultActiveKey={1}
                    id="uncontrolled-tab-example"
                >
                    <Tab eventKey={1} title="Login">
                        <Login push={ this.props.history.push } />
                    </Tab>
                    <Tab eventKey={2} title="Register">
                        <Register />
                    </Tab>
                </Tabs>
            </div>
        )
    }
}