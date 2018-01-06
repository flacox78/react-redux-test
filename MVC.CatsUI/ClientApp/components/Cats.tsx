import * as React from 'react';
import { Link, RouteComponentProps } from 'react-router-dom';
import { connect } from 'react-redux';
import { ApplicationState } from '../store';
import * as CatsState from '../store/Cats';

type CatsProps =
    CatsState.CatsState                 // State from Redux
    & typeof CatsState.actionCreators   // Action
    & RouteComponentProps<{}>;           // Routing parameters

enum OwnerGender {
    Male = "Male",
    Female = "Female"
};

class Cats extends React.Component<CatsProps, {}> {

    // This method runs when the component is first added to the page - Set Props
    componentWillMount() {
        this.props.requestCats();
    }

    // This method runs when incoming props (e.g., route params) change - Set Props
    componentWillReceiveProps(nextProps: CatsProps) {
        
    }

    public render() {
        return <div>
            <h1>{OwnerGender.Male.toString()}</h1>  
            {this.renderCatsList(OwnerGender.Male)}

            <h1>{OwnerGender.Female.toString()}</h1>  
            {this.renderCatsList(OwnerGender.Female)}
        </div>;
    }

    private renderCatsList(ownerGender: OwnerGender) {
        return <ul className='list-group'>                   
                    {this.props.cats
                        .filter(cat => cat.ownerGender === ownerGender.toString())
                        .sort((a,b) => a.petName < b.petName ? -1 : (a.petName > b.petName ? 1 : 0))
                        .map((cat,i) =>
                            <li key={ i } className="list-group-item">{cat.petName} </li>
                     )}
                </ul>;
    }    
}

// Wire up the React component to the Redux store
export default connect(
    (state: ApplicationState) => state.cats,    // Selects which state properties are merged into the component's props
    CatsState.actionCreators                    // Selects which action creators are merged into the component's props
)(Cats) as typeof Cats;



