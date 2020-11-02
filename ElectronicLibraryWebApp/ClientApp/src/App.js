import * as React from 'react';
import { Route } from 'react-router';
import Layout from './components/Layout';
import Home from './components/Home';

import './custom.css'
import { SignIn } from './pages/Signin';

export default () => (
    <Layout>
        <Route exact path='/' component={Home} />
        <Route path='/signin' component={SignIn} />
    </Layout>
);
