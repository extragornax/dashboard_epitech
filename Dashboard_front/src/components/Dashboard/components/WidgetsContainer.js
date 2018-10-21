import React, { Component } from 'react';
import Widget from './Widget';
import axios from 'axios'
import './Widget.css';

export default class WidgetsContainer extends Component {
	constructor(props) {
		super(props);
	
	this.state = {
		data: [],
		meteoData: [],
		apiWidgetAPI: "/api/Widget/",
		test: "ck",
		ServiceList:"/api/Service/",
		meteoURL:"",
	}
	this.getMeteo=this.getMeteo.bind(this);
	}
	createAPIRequest(ID) {
		const APIRquest = this.state.apiWidgetAPI+ID+"/invoke"
		return (APIRquest)
	}
	getMeteo() {
		axios.get('/api/Service').then(res => {
			this.data=res.data;
			this.setState({test: "PTAZZAT"});
			this.setState({meteoURL: this.createAPIRequest(this.data[0].widgets[0].id)});
			
		})
		axios.get(this.state.meteoURL).then (rep => {
			this.setState({meteoData: rep.data})
		})
		return (
			<div>
				<div>coucou</div>
				<div>coucou</div>
			</div>
		)
		// /* A checker le retour de la requête */
		// localStorage.setItem('token', res.data);
	}

    render() {
        return (
            <div className="widgets-container">
                <Widget
                    title="Météo"
                    content={this.getMeteo()}
                />
                <Widget
                    title="Météo"
                    content="Degrés"
                />
            </div>
        )
    }
};