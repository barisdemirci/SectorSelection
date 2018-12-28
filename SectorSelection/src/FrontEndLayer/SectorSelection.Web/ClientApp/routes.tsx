import * as React from 'react';
import { Route } from 'react-router-dom';
import { Layout } from './components/Layout';
import SectorSelection from './components/SectorSelection';
import FetchData from './components/FetchData';
import Counter from './components/Counter';

export const routes = <Layout>
    <Route exact path='/' component={SectorSelection} />
    <Route path='/counter' component={Counter} />
    <Route path='/fetchdata/:startDateIndex?' component={FetchData} />
</Layout>;
