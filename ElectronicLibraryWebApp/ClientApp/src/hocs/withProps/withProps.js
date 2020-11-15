import React from 'react';

export const withProps = (WrappedComponent, handle) => {
    return <WrappedComponent handle={handle}/>
}