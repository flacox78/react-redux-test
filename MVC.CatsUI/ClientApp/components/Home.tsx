import * as React from 'react';
import { RouteComponentProps } from 'react-router-dom';

export default class Home extends React.Component<RouteComponentProps<{}>, {}> {
    public render() {
        return <div>
            <h1>AGL - Test</h1>
            <p>Single Page application, built with:</p>
            <ul>
                <li><b>ASP.NET Core</b> and <b>C#</b> for cross-platform server-side code</li>
                <li><b>React</b>, <b>Redux</b> and <b>TypeScript</b> for client-side code</li>
                <li><b>Webpack</b> for building and bundling client-side resources</li>
                <li><b>Bootstrap</b> for layout and styling</li>
            </ul> 
        </div>;
    }
}
