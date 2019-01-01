import * as React from 'react';
import { RouteComponentProps } from 'react-router-dom';
import { fetch } from 'domain-task';
export interface HomeState { sectors: Sector[], name: string, selectedSectors: string[], isLoaded: boolean, agreed: boolean, formValidations: HomeValidation, loadOptionList: boolean, sectorsLoadList: any };

const formValid = (formValidations: any, name: any, selectedSectors: string[]) => {
    let valid = true;
    //validate form errors being empty
    var agreeCheckBoxElement: any = document.getElementById("agreed");
    if (agreeCheckBoxElement) {
        var agreed = agreeCheckBoxElement.checked;
        if (!agreed) {
            formValidations.agreed = "You must accept.";
            valid = false;
        }
        else {
            formValidations.agreed = "";
        }
    }
    if (selectedSectors.length == 0) {
        valid = false;
        formValidations.sector = "You must select at least one sector. ";
    }
    if (selectedSectors.length == 0) {
        formValidations.name = "Name is required!";
    }
    var values = Object.keys(formValidations).map(function (key) {
        return formValidations[key];
    });
    values.forEach((val: string) => {
        if (val.length > 0) valid = false;
    });

    return valid;
}

export default class SectorSelection extends React.Component<RouteComponentProps<{}>, HomeState> {
    constructor(props: RouteComponentProps<{}>) {
        super(props);
        var userName = props.location.state ? props.location.state.userName : "";
        var loadOptionList = userName != "";
        this.state = {
            sectors: [],
            isLoaded: false,
            name: userName,
            selectedSectors: [],
            agreed: false,
            loadOptionList: loadOptionList,
            sectorsLoadList: loadOptionList ? props.location.state.sectors : [],
            formValidations: {
                name: "",
                sector: "",
                agreed: ""
            },
        };
    }

    componentDidMount() {
        this.getSectors();
    }

    private setOptions() {
        if (this.state.loadOptionList) {
            var sectors = this.state.sectorsLoadList;
            var options: any = document.getElementById("sectors");
            var selectedSectors = [];
            for (var i = 0; i < sectors.length; i++) {
                for (var j = 0; j < options.length; j++) {
                    var searchText = options[j].innerHTML.split("&nbsp;").join("");
                    if (searchText == sectors[i].sectorName) {
                        options[j].selected = true;
                        selectedSectors.push(options[j].value);
                        break;
                    }
                }
            }
            this.setState({ selectedSectors: selectedSectors });
        }
    }

    public render() {
        const formValidations = this.state.formValidations;

        if (this.state.isLoaded) {
            return <div>
                <h1>User Sectors</h1>
                <p>Please enter your name and pick the Sectors you are currently involved in.</p>
                <form onSubmit={this.handleSubmit.bind(this)}>
                    <div className="name">
                        <div className="col-sm-2">
                            <label htmlFor="name">Name :</label>
                        </div>
                        <div className="col-sm-4">
                            <input name="name" type="text" onChange={this.nameTextBoxChanged.bind(this)} defaultValue={this.state.name} className={formValidations.name.length == 0 ? "" : "error"} />
                            <div>
                                {formValidations.name.length > 0 &&
                                    <span className="errormessage">{formValidations.name}</span>}
                            </div>
                        </div>
                    </div>
                    <div className="clear" />
                    <div className="sector">
                        <div className="col-sm-2">
                            <label htmlFor="sectors">Sectors:</label>
                        </div>
                        <div className="col-sm-4">
                            <select id="sectors" name="sectors" multiple onChange={this.sectorSelected.bind(this)} className={formValidations.sector.length == 0 ? "sectors" : "sectors error"}>
                                {this.state.sectors.map(item =>
                                    <option key={item.value} value={item.value}>{item.sectorName}</option>
                                )}
                            </select>
                            <div>
                                {formValidations.sector.length > 0 &&
                                    <span className="errormessage">{formValidations.sector}</span>}
                            </div>
                        </div>
                    </div>
                    <div className="clear" />
                    <div className="col-sm-12">
                        <input id="agreed" type="checkbox" name="agreed" />
                        <label htmlFor="agreed"> Agree to terms </label>
                        <div>
                            {formValidations.agreed.length > 0 &&
                                <span className="errormessage">{formValidations.agreed}</span>}
                        </div>
                    </div>
                    <div className="clear" />
                    <div className="col-sm-6 pull-right">
                        <input className="buttonSave" type="submit" value="Save" />
                    </div>
                </form>
            </div>;
        }
        else {
            return <div> Loading... </div>
        }
    }

    private nameTextBoxChanged(e: any) {
        e.preventDefault();
        this.setState({ name: e.target.value });
        this.state.formValidations.name = e.target.value.length == 0 ? "Name is required!" : "";
    }

    private sectorSelected(e: any) {
        e.preventDefault();
        var options = e.target.options;
        var selectedSectors = [];
        for (var i = 0, l = options.length; i < l; i++) {
            if (options[i].selected) {
                selectedSectors.push(options[i].value);
            }
        }
        this.setState({ selectedSectors: selectedSectors });
        this.state.formValidations.sector = selectedSectors.length == 0 ? "You must select at least one sector!" : "";
    }

    private handleSubmit(e: any) {
        e.preventDefault();
        if (formValid(this.state.formValidations, this.state.name, this.state.selectedSectors)) {
            this.postSelectedSectors(this.state.name, this.state.selectedSectors);
        }
        else {
            this.setState({ isLoaded: true });
            alert("Form is not valid! Please fill and select all fields!");
        }
    }

    private onSaveButtonClicked(e: any) {
        e.preventDefault();
    }

    private getSectors() {
        fetch("http://localhost:5000/sectors")
            .then(res => res.json())
            .then(
                (result) => {
                    this.setState({
                        sectors: result,
                        isLoaded: true
                    });
                    this.setOptions();
                },
                (error) => {
                    this.setState({
                        isLoaded: true
                    });
                }
            );
    }

    private postSelectedSectors(name?: string, selectedSectors?: string[]) {
        var agreeCheckBoxElement: any = document.getElementById("agreed");
        var agreed = agreeCheckBoxElement.checked;
        const data = { name, selectedSectors, agreed };
        let requestHeaders: any = { 'Content-Type': 'application/json' };
        fetch("http://localhost:5000/sectors", {
            method: "POST",
            headers: requestHeaders,
            body: JSON.stringify(data)
        })
            .then(res => alert("Successfully!"));
    }
}

export interface Sector {
    value: number
    parentId: any,
    sectorName: string
}

export interface HomeValidation {
    name: string,
    sector: string,
    agreed: string
}
