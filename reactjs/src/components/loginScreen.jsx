import React, { Component } from "react";
import {
  Button,
  FormGroup,
  FormControl,
  ControlLabel,
  ButtonToolbar
} from "react-bootstrap";

// const centerScreen = {margin-left: auto, margin-right: auto};
const buttonStyle = { width: 150, margin: "0 auto" };
const inputStyle = { width: 300, margin: "auto", };
const center = { margin: "auto" };
const sectionBackground = {
  background: '#56a6bf', display: "block", height: "auto", width: "auto", position: "relative",
  margin: "10px"
};

const test = {
  display: "block",
  width: "600px",
  position: "absolute",
  top: "40%",
  left: "50%",
  padding: "10px",
  margin: "auto",
  border: "2px solid #0984e3",
  height: "auto",
  background: "#dfe6e9",
  transform: "translate(-50%, -50%)"
};
const microsoftLogoLink =
  "http://icons-for-free.com/free-icons/png/512/718952.png";


class LoginScreen extends Component {
  state = {
    email: "",
    password: ""
  };
  modifyStateMail = event => {
    this.setState({
      ...this.state,
      email: event.target.value
    });
  }
  modifyStatePassword = event => {
    this.setState({
      ...this.state,
      password: event.target.value
    });
  }
  render() {
    return (
      <div>
        <img src="https://images.pexels.com/photos/733853/pexels-photo-733853.jpeg?auto=compress&cs=tinysrgb&h=750&w=1260" class="rounded mx-auto d-block" alt="pic"></img>
        <section id="Login" style={test}>
          <div>
            <FormGroup id="email" bsSize="small">
              <div style={inputStyle} >
                <ControlLabel>
                  Email
              </ControlLabel>
                <FormControl value={this.state.email} autoFocus onChange={this.modifyStateMail}
                  type="email">
                </FormControl>
                <ControlLabel>
                  Password
              </ControlLabel>
                <FormControl value={this.state.password} onChange={this.modifyStatePassword} type="password">
                </FormControl>
                <button type="button" class="btn btn-outline-secondary">Login</button>
              </div>
            </FormGroup>
          </div>
        </section>
        <div>
        <section id="Register">
          <div className="well" style={buttonStyle}>
            <Button bsStyle="default" bsSize="small" block>
              <img
                style={{ width: "25px", height: "25px",margin: "auto",
              }}
              />
              Register
            </Button>
          </div>
        </section>
        <section id="OAuth">
          <div className="well" style={buttonStyle}>
            <Button bsStyle="success" bsSize="small" block>
              <img
                src={microsoftLogoLink}
                style={{ width: "25px", height: "25px"}}
              />
              Microsoft Login
            </Button>
          </div>
        </section>
        </div>
      </div >
    );
  }
}

export default LoginScreen;
