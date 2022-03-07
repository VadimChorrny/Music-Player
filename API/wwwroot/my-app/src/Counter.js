import React, { Component } from "react";

export default class Counter extends Component {
    constructor(props) {
        super(props); // call ctor

        this.state = {
            counter: 0,
        };

        this.increment = this.increment.bind(this);
        this.decrement = this.decrement.bind(this);
        this.reset = this.reset.bind(this);
    }

    increment() {
        this.setState((state) => ({
            counter: state.counter + 1,
        }));
    }

    decrement() {
        this.setState((state) => ({
            counter: state.counter - 1,
        }));
    }

    reset() {
        this.setState((state) => ({
            counter: 0,
        }));
    }

    render() {
        return (
            <div>
                <h1>{this.state.counter}</h1>
                <button onClick={this.increment}>+</button>
                <button onClick={this.decrement}>-</button>
                <button onClick={this.reset}>reset</button>
            </div>
        );
    }
}
