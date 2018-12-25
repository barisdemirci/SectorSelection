import * as React from 'react';

export interface DropDownProps {
    items: DropDownItem[];
}

export interface DropDownItem {
    value: string;
    text: string;
}

export class DropDown extends React.Component<DropDownProps, {}> {
    public render() {
        var items = this.props.items == undefined ? [] : this.props.items;
        return <div>
            <select multiple>
                {items.map(item =>
                    <option value={item.value}>{item.text}</option>
                )}
            </select>
        </div>
    }
}