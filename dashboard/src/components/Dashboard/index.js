import React, { Component } from 'react';
import DashboardNavbar from '../DashboardNavbar';
import WidgetsContainer from './components/WidgetsContainer';

export default class Dashboard extends Component {
    componentDidMount() {
        if (!localStorage.getItem('token'))
            this.props.history.push('/connection');
    }

    render() {
        return (
            <div>
                <DashboardNavbar push={ this.props.history.push } />
                <WidgetsContainer />
            </div>
        );
    }
}