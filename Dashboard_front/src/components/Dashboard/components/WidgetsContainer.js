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
		apiWidgetAPI: "api/Widget/",
		test: "ck",
		ServiceList:"/api/Service/",
		meteoURL:"",
		rssURL:"",
		rssData: [],
		setter: 0,
		cat: [],
		rssFlux0: [],
		rssFlux1: [],
		rssFlux2: [],
		rssFlux3: [],
		rssFlux4: [],
		rssFlux5: [],
		rssFlux6: [],
		rssFlux7: [],
		rssFlux8: [],
		rssFlux9: [],
		rssFlux10: [],
		rssFlux11: [],
		rssFlux12: [],
		rssFlux13: [],
		rssFlux14: [],
		rssFlux15: [],
	}
	this.getMeteo=this.getMeteo.bind(this);
}
componentDidMount() {
	axios.get('/api/Service').then(res => {
		this.data=res.data;
		this.setState({meteoURL: this.createAPIRequest(this.data[0].widgets[0].id)});	
		this.setState({rssURL: this.createAPIRequest(this.data[1].widgets[0].id)});
	}).then(res => {
		axios.get(this.state.meteoURL).then(rep => {
			this.setState({meteoData: rep.data})
		});
		axios.get(this.state.rssURL).then(rep => {
			this.setState({rssData: rep.data});
			this.setState({cat: rep.data.rss.channel})
			this.setState({rssFlux0: rep.data.rss.channel.item[0]})
			this.setState({rssFlux1: rep.data.rss.channel.item[1]})
			this.setState({rssFlux2: rep.data.rss.channel.item[2]})
			this.setState({rssFlux3: rep.data.rss.channel.item[3]})
			this.setState({rssFlux4: rep.data.rss.channel.item[4]})
			this.setState({rssFlux5: rep.data.rss.channel.item[5]})
			this.setState({rssFlux6: rep.data.rss.channel.item[6]})
			this.setState({rssFlux7: rep.data.rss.channel.item[7]})
			this.setState({rssFlux8: rep.data.rss.channel.item[8]})
			this.setState({rssFlux9: rep.data.rss.channel.item[9]})
			this.setState({rssFlux10: rep.data.rss.channel.item[10]})
			this.setState({rssFlux11: rep.data.rss.channel.item[11]})
			this.setState({rssFlux12: rep.data.rss.channel.item[12]})
			this.setState({rssFlux13: rep.data.rss.channel.item[13]})
			this.setState({rssFlux14: rep.data.rss.channel.item[14]})
		});
	})

}
createAPIRequest(ID) {
	const APIRquest = this.state.apiWidgetAPI+ID+"/invoke"
	return (APIRquest)
}
getRSSName() {
	return (
		<div>
			{this.state.cat.title}
		</div>		
		)
	}
	getMeteo() {
		console.log(this.state.meteoData);
	}
	
getRSSList() {
	return (
		<div>
			<div>
				<ul>
					<a href={this.state.rssFlux0.link}>{this.state.rssFlux0.title}</a>
					<p>{this.state.rssFlux0.pubDate}</p>
					<p>{this.state.rssFlux0.description}</p>
				</ul>
				<ul>
					<a href={this.state.rssFlux1.link}>{this.state.rssFlux1.title}</a>
					<p>{this.state.rssFlux1.pubDate}</p>
					<p>{this.state.rssFlux1.description}</p>
				</ul>
				<ul>
					<a href={this.state.rssFlux2.link}>{this.state.rssFlux2.title}</a>
					<p>{this.state.rssFlux2.pubDate}</p>
					<p>{this.state.rssFlux2.description}</p>
				</ul>
				<ul>
					<a href={this.state.rssFlux3.link}>{this.state.rssFlux3.title}</a>
					<p>{this.state.rssFlux3.pubDate}</p>
					<p>{this.state.rssFlux3.description}</p>
				</ul>
				<ul>
					<a href={this.state.rssFlux4.link}>{this.state.rssFlux4.title}</a>
					<p>{this.state.rssFlux4.pubDate}</p>
					<p>{this.state.rssFlux4.description}</p>
				</ul>
				<ul>
					<a href={this.state.rssFlux5.link}>{this.state.rssFlux5.title}</a>
					<p>{this.state.rssFlux5.pubDate}</p>
					<p>{this.state.rssFlux5.description}</p>
				</ul>
				<ul>
					<a href={this.state.rssFlux6.link}>{this.state.rssFlux6.title}</a>
					<p>{this.state.rssFlux6.pubDate}</p>
					<p>{this.state.rssFlux6.description}</p>
				</ul>
				<ul>
					<a href={this.state.rssFlux7.link}>{this.state.rssFlux7.title}</a>
					<p>{this.state.rssFlux7.pubDate}</p>
					<p>{this.state.rssFlux7.description}</p>
				</ul>
				<ul>
					<a href={this.state.rssFlux8.link}>{this.state.rssFlux8.title}</a>
					<p>{this.state.rssFlux8.pubDate}</p>
					<p>{this.state.rssFlux8.description}</p>
				</ul>
				<ul>
					<a href={this.state.rssFlux9.link}>{this.state.rssFlux9.title}</a>
					<p>{this.state.rssFlux9.pubDate}</p>
					<p>{this.state.rssFlux9.description}</p>
				</ul>
				<ul>
					<a href={this.state.rssFlux10.link}>{this.state.rssFlux10.title}</a>
					<p>{this.state.rssFlux10.pubDate}</p>
					<p>{this.state.rssFlux10.description}</p>
				</ul>
				<ul>
					<a href={this.state.rssFlux11.link}>{this.state.rssFlux11.title}</a>
					<p>{this.state.rssFlux11.pubDate}</p>
					<p>{this.state.rssFlux11.description}</p>
				</ul>
				<ul>
					<a href={this.state.rssFlux12.link}>{this.state.rssFlux12.title}</a>
					<p>{this.state.rssFlux12.pubDate}</p>
					<p>{this.state.rssFlux12.description}</p>
				</ul>
				<ul>
					<a href={this.state.rssFlux13.link}>{this.state.rssFlux13.title}</a>
					<p>{this.state.rssFlux13.pubDate}</p>
					<p>{this.state.rssFlux13.description}</p>
				</ul>
				<ul>
					<a href={this.state.rssFlux14.link}>{this.state.rssFlux14.title}</a>
					<p>{this.state.rssFlux14.pubDate}</p>
					<p>{this.state.rssFlux14.description}</p>
				</ul>
			</div>
		
		</div>

	)
}
    render() {
        return (
            <div className="widgets-container">
                <Widget
                    title="Météo"
                    content={this.getMeteo()}
                />
                <Widget
                    title={this.getRSSName()}
                    content={this.getRSSList()}
                />
            </div>
        )
    }
};