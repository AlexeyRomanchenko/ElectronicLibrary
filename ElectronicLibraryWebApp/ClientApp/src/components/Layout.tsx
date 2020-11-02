import * as React from 'react';
import {NavMenu} from './NavMenu/NavMenu';

export default (props: { children?: React.ReactNode }) => (
    <>
        <NavMenu/>
        <>
            {props.children}
        </>
    </>
);
