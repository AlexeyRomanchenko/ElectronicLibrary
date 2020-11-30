import React from 'react';
import { Grid } from '../../../components/common/grid';

const columns = [
    { field: 'id', headerName: 'ID', flex: 0.2 },
    { field: 'message', headerName: 'Message', flex: 2 },
    { field: 'username', headerName: 'Username', flex: 1 },
    {
        field: 'book',
        headerName: 'Book',
        valueGetter: (params) =>
            `${params.getValue('book')?.name || ''}`,
        flex: 1
    }
];

export const Logs = () => {
    return (
        <p>System logs</p>
        <Grid columns={columns} data={[]}/>
        );
}