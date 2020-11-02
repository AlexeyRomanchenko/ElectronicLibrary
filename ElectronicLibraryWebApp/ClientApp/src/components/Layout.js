import * as React from 'react';
import {NavMenu} from './NavMenu/NavMenu';

export default (props) => (
    <>
        <NavMenu/>
        <>
            {props.children}
        </>
    </>
);
