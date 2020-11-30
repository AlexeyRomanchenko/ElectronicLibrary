import React, { useEffect ,useState} from 'react';
import axios from 'axios';
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
    const [logs, setLogs] = useState([]);
    useEffect(() => {
        axios.get('/api/logger').then(response => {
            if (response.status === 200) {
                setLogs(response.data);
            }
        });
    }, []);
    return (
        <>
            <p>System logs</p>
            <Grid columns={columns} data={logs} />
        </>
        );
}