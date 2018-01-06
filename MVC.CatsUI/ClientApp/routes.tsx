import * as React from 'react';
import { Route } from 'react-router-dom';
import { Layout } from './components/Layout';
import Home from './components/Home';
import Cats from './components/Cats';

export const routes = <Layout>
    <Route exact path='/' component={ Home } />
    <Route path='/fetchCats' component={Cats} />
</Layout>;
