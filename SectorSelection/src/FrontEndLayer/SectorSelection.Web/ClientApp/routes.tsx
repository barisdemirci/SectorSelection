import * as React from 'react';
import { Route } from 'react-router-dom';
import { Layout } from './components/Layout';
import SectorSelection from './components/SectorSelection';
import FetchData from './components/FetchData';

export const routes = <Layout>
    <Route exact path='/' component={SectorSelection} />
    <Route path='/fetchdata/:startDateIndex?' component={FetchData} />
</Layout>;
