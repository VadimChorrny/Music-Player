import React, { Component } from "react";

export default class FormComponent extends Component {
    constructor(props) {
        super(props);

        this.state = {
            input: "",
            submit: "",
        };

        this.handleChange = this.handleChange.bind(this);
        this.handleSubmit = this.handleChange.bind(this);
    }

    handleChange(event) {
        this.setState({
            input: event.target.value, // тут витягуємо значення інпута
        });
    }
    handleSubmit(event) {
        event.preventDefault();
        this.setState({
            submit: this.state.input,
        });
    }
    render() {
        return (
            <div>
                <form onSubmit={this.handleSubmit}>
                    <input
                        value={this.state.input}
                        onChange={this.handleChange}
                    />
                    <button type="submit">Submit</button>
                </form>
                <h3>{this.state.submit}</h3>
            </div>
        );
    }
}
