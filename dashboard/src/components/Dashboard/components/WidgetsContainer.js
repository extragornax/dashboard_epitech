import React, { Component } from 'react';
import Widget from './Widget';
import './Widget.css';

export default class WidgetsContainer extends Component {
    render() {
        return (
            <div className="widgets-container">
                <Widget
                    content="Degrés"
                    title="Météo"
                />
                <Widget
                    title="Météo"
                    content="Degrés"
                />
                <Widget
                    title="Météo"
                    content="Degrés"
                />
                <Widget
                    title="Météo"
                    content="Degrés"
                />
                <Widget
                    title="Météo"
                    content="Degrés"
                />
                <Widget
                    title="Météo"
                    content="Degrés"
                />
                <Widget
                    title="Météo"
                    content="Degrés"
                />
                <Widget
                    title="Météo"
                    content="Degrés"
                />
            </div>
        )
    }
};