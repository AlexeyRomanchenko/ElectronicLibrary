import React, {useState, useEffect} from 'react';
import axios from 'axios';
import Button from '@material-ui/core/Button';
import { Grid } from '../../../components/common/grid';

const changeUserStatus = (id, status) => {
    console.log(status);
    axios.put(`/api/BlockedUser/${id}`, JSON.stringify(status), {
        headers: {
            'Content-Type': 'application/json',
        }
    }).then(response => {
        if (response.status === 200) {
            console.log(response);
        }
    });
}

const columns = [
    { field: 'id', headerName: 'ID', flex: 1.5},
    { field: 'username', headerName: 'Username', flex: 1},
    {
        field: 'isBlocked',
        headerName: ` `,
        flex: 0.2,
        disableClickEventBubbling: true,
        renderCell: (params) => {
            const isBlocked = params.value;
                return <Button
                    variant="contained"
                    fullWidth
                    onClick={() => { changeUserStatus(params.rowModel.id, !isBlocked)}}
                    color={isBlocked ? "primary" : "secondary"}
                    size="small"
                >
                    {isBlocked ? "unblock" : "block"}
        </Button>
            
        },
    }
  ];
  
export const UserList = () => {
    const [users, setUsers] = useState([]);
    useEffect(
        ()=> {
            axios.get('/api/user')
            .then(response=> {
                if(response.status === 200) {
                    setUsers(response.data);
                }
            });
        }
    ,[]);
    return (
        <Grid columns={columns} data={users}/>
    );
}