import * as React from 'react';
import { RouteComponentProps } from 'react-router-dom';
import { DropDown, DropDownItem } from './controls/dropdown'
export interface HomeState { sectors: any, isLoaded: boolean };

export default class Home extends React.Component<RouteComponentProps<{}>, HomeState> {
    constructor(props: RouteComponentProps<{}> | undefined) {
        super(props);
        this.state = { sectors: [], isLoaded: false };
    }

    componentWillMount() {
        this.getSectors().then(response => {
            this.setState({
                sectors: response,
                isLoaded: false
            });
        });
    }

    componentDidMount() {

    }

    public render() {
        if (this.state.isLoaded) {
            return <div>
                Please enter your name and pick the Sectors you are currently involved in.
            <br />
                <br />
                Name:
            <input type="text" />
                <br />
                <br />
                Sectors:
                <DropDown items={this.state.sectors} />
                <br />
                <br />
                <input type="checkbox" /> Agree to terms
            <br />
                <br />
                <input type="submit" value="Save" />
            </div>;
        }
        else {
            return <div> Loading... </div>
        }
    }

    private async getSectors() {
        await fetch("http://localhost:5000/sectors").then(response => {
            return response;
        });
    }
}