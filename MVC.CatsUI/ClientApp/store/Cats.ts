import { fetch, addTask } from 'domain-task';
import { Action, Reducer, ActionCreator } from 'redux';
import { AppThunkAction } from './';

// STATE - This defines the type of data maintained in the Redux store.
export interface CatsState {
    cats: Cats[];
}

export interface Cats {
    ownerGender: string;
    petName: string;
}

// ACTIONS
interface RequestCatsAction {
    type: 'REQUEST_CATS';
}

interface ReceiveCatsAction {
    type: 'RECEIVE_CATS';
    cats: Cats[];
}

// Avoid been declare in other arbitrary string
type KnownAction = RequestCatsAction | ReceiveCatsAction;

// Creators - functions exposed to UI components that will trigger a state transition
export const actionCreators = {
    requestCats: (): AppThunkAction<KnownAction> => (dispatch, getState) => {
        let fetchTask = fetch(`api/Cats/CatByGender`)
            .then(response => response.json() as Promise<Cats[]>)
            .then(data => {
                dispatch({ type: 'RECEIVE_CATS', cats: data });
            });

        addTask(fetchTask); // Ensure server-side prerendering waits for this to complete
        dispatch({ type: 'REQUEST_CATS' });
    }
}

// REDUCER - For a given state and action, returns the new state
const unloadedState: CatsState = { cats: [] }

export const reducer: Reducer<CatsState> = (state: CatsState, incomingAction: Action) => {
    const action = incomingAction as KnownAction;
    switch (action.type) {
        case 'REQUEST_CATS':
            return {
                cats: state.cats
            };
        case 'RECEIVE_CATS':
            return {
                cats: action.cats
            };            
        default:
            // The following line guarantees that every action in the KnownAction union has been covered by a case above
            const exhaustiveCheck: never = action;
    }

    return state || unloadedState;
}
