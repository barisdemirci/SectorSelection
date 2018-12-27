import * as React from 'react';
import { RouteComponentProps } from 'react-router-dom';
import { fetch } from 'domain-task';
export interface HomeState { sectors: Sector[], name: string, selectedSectors: string[], isLoaded: boolean, agreed: boolean, formValidations: HomeValidation };

const formValid = (formValidations: any, selectedSectors: string[]) => {
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
    var values = Object.keys(formValidations).map(function (key) {
        return formValidations[key];
    });
    values.forEach((val: string) => {
        if (val.length > 0) valid = false;
    });

    return valid;
}

export default class Home extends React.Component<RouteComponentProps<{}>, HomeState> {
    constructor(props: RouteComponentProps<{}> | undefined) {
        super(props);
        this.state = {
            sectors: [],
            isLoaded: false,
            name: "",
            selectedSectors: [],
            agreed: false,
            formValidations: {
                name: "",
                sector: "",
                agreed: ""
            }
        };
    }

    componentDidMount() {
        this.getSectors();
    }

    public render() {
        const formValidations = this.state.formValidations;

        if (this.state.isLoaded) {
            return <form onSubmit={this.handleSubmit.bind(this)}>
                <div>
                    <label> Please enter your name and pick the Sectors you are currently involved in. </label>
                </div>
                <div className="name">
                    <label htmlFor="name">Name :</label>
                    <input name="name" type="text" onChange={this.nameTextBoxChanged.bind(this)} className={formValidations.name.length == 0 ? "" : "error"} />
                    <div>
                        {formValidations.name.length > 0 &&
                            <span>{formValidations.name}</span>}
                    </div>
                </div>
                <br />
                <br />
                <div className="sector">
                    <label htmlFor="sectors">Sectors:</label>
                    <select name="sectors" multiple onChange={this.sectorSelected.bind(this)} className={formValidations.sector.length == 0 ? "" : "error"}>
                        {this.state.sectors.map(item =>
                            <option key={item.value} value={item.value}>{item.sectorName}</option>
                        )}
                    </select>
                    <div>
                        {formValidations.sector.length > 0 &&
                            <span>{formValidations.sector}</span>}
                    </div>
                </div>
                <br />
                <br />
                <div className="agreed">
                    <input id="agreed" type="checkbox" name="agreed" />
                    <label htmlFor="agreed"> Agree to terms </label>
                    <div>
                        {formValidations.agreed.length > 0 &&
                            <span>{formValidations.agreed}</span>}
                    </div>
                </div>
                <br />
                <br />
                <div>
                    <input type="submit" value="Save" />
                </div>
            </form>;
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
        this.state.formValidations.sector = selectedSectors.length == 0 ? "You must select at least one sector " : "";
    }

    private handleSubmit(e: any) {
        e.preventDefault();
        if (formValid(this.state.formValidations, this.state.selectedSectors)) {
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
        });
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
