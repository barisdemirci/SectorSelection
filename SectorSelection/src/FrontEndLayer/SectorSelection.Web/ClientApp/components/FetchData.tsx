import * as React from 'react';
import { Link, RouteComponentProps } from 'react-router-dom';
import { connect } from 'react-redux';
import { ApplicationState } from '../store';
import * as WeatherForecastsState from '../store/WeatherForecasts';
import { fetch } from 'domain-task';
export interface FetchState { userSectors: UserSector[], isLoaded: boolean };
import { BootstrapTable, TableHeaderColumn } from 'react-bootstrap-table';

// At runtime, Redux will merge together...
type WeatherForecastProps =
    WeatherForecastsState.WeatherForecastsState        // ... state we've requested from the Redux store
    & typeof WeatherForecastsState.actionCreators      // ... plus action creators we've requested
    & RouteComponentProps<{ startDateIndex: string }>; // ... plus incoming routing parameters

export interface UserSector {
    Id: number
    userName: string,
    sectorName: string
}

class FetchData extends React.Component<WeatherForecastProps, FetchState> {

    constructor(props: WeatherForecastProps | undefined) {
        super(props);
        this.state = {
            userSectors: [],
            isLoaded: false
        };
    }

    componentWillMount() {
        // This method runs when the component is first added to the page
        let startDateIndex = parseInt(this.props.match.params.startDateIndex) || 0;
        this.props.requestWeatherForecasts(startDateIndex);
    }

    componentDidMount() {
        this.getUserSectors();
    }

    componentWillReceiveProps(nextProps: WeatherForecastProps) {
        // This method runs when incoming props (e.g., route params) change
        let startDateIndex = parseInt(nextProps.match.params.startDateIndex) || 0;
        this.props.requestWeatherForecasts(startDateIndex);
    }

    public render() {
        var state = this.state;
        return <div>
            <h1>User Sectors</h1>
            <p>This component shows users with sectors. You can edit sectors by clicking related row</p>
            {this.renderBootStrap(state.userSectors)}
        </div>;
    }

    private renderBootStrap(sectors: any) {
        const options: any = {
            expandRowBgColor: 'rgb(242, 255, 163)',
            expandBy: 'column'  // Currently, available value is row and column, default is row
        };

        return <BootstrapTable data={sectors} version='4'
            options={options}
            striped
            expandableRow={this.isExpandableRow}
            expandComponent={this.expandComponent}
            search>
            <TableHeaderColumn dataField='userName' isKey>User Name</TableHeaderColumn>
        </BootstrapTable>
    }

    private isExpandableRow(row: any) {
        return true;
    }

    private expandComponent(row: any) {
        return (
            <BSTable sectors={row.sectors} />
        );
    }

    private getUserSectors() {
        fetch("http://localhost:5000/usersectors")
            .then(res => res.json())
            .then(
                (result) => {
                    this.setState({
                        userSectors: result,
                        isLoaded: true
                    });
                },
                (error) => {
                    this.setState({
                        isLoaded: true
                    });
                }
            );
    }
}

class BSTable extends React.Component<any, {}> {
    render() {
        if (this.props.sectors) {
            return (
                <BootstrapTable data={this.props.sectors}>
                    <TableHeaderColumn dataField='sectorName' isKey>Sectors</TableHeaderColumn>
                </BootstrapTable>);
        } else {
            return (<p>?</p>);
        }
    }
}

export default connect(
    (state: ApplicationState) => state.weatherForecasts, // Selects which state properties are merged into the component's props
    WeatherForecastsState.actionCreators                 // Selects which action creators are merged into the component's props
)(FetchData) as typeof FetchData;
