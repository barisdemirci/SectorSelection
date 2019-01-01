import * as React from 'react';
import { NavLink, Link, RouteComponentProps } from 'react-router-dom';
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
            <h1>User's Sectors</h1>
            <p>This component shows users with sectors.</p>
            <p>You can edit sectors by clicking related row.</p>
            <p>You can expand rows by clicking first column.</p>
            {this.renderBootStrap(state.userSectors)}
        </div>;
    }

    private renderBootStrap(sectors: any) {
        const options: any = {
            expandRowBgColor: 'rgb(242, 255, 163)',
            expandBy: 'column'
        };

        return <BootstrapTable data={sectors} version='4'
            options={options}
            striped
            expandableRow={this.isExpandableRow}
            expandComponent={this.expandComponent}
            search>
            <TableHeaderColumn dataField='userName' isKey>User Name</TableHeaderColumn>
            <TableHeaderColumn expandable={false} dataFormat={this.editSection}>
                Edit
            </TableHeaderColumn>
        </BootstrapTable>
    }

    private onClickProductSelected(cell: any, row: any) {
        var a = "2";
    }

    private buttonFormatter(cell: any, row: any) {
        var self = this;
        return (<button
            type="button"
            onClick={
                () =>
                    self.onClickProductSelected(cell, row)
            }
        >
            Edit
        </button>);
    }

    private navigateButton(row: any) {
        var data = row;
    }

    private editSection(cell: any, row: any) {
        var data: any = { userName: row.userName, sectors: row.sectors };
        return (<div>
            <Link to={{ pathname: '/', state: data }}>
                <span>Edit</span>
            </Link>
        </div>);
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
                <div>
                    <BootstrapTable data={this.props.sectors}>
                        <TableHeaderColumn dataField='sectorName' isKey>Sectors</TableHeaderColumn>
                    </BootstrapTable>
                </div>);
        } else {
            return (<p>?</p>);
        }
    }
}

export default connect(
    (state: ApplicationState) => state.weatherForecasts, // Selects which state properties are merged into the component's props
    WeatherForecastsState.actionCreators                 // Selects which action creators are merged into the component's props
)(FetchData) as typeof FetchData;
