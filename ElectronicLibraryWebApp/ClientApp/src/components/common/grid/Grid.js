import React from 'react';
import { DataGrid } from '@material-ui/data-grid';

export const Grid = ({columns = [], data = []}) => {
    console.log(data);
    return (
    <div style={{ height: 400, width: '100%' }}>
        <DataGrid rows={data} columns={columns} pageSize={5} />
    </div>);
}