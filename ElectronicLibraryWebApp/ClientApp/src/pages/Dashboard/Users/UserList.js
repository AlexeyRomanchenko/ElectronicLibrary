import React, {useState, useEffect} from 'react';
import axios from 'axios';
import { Grid } from '../../../components/common/grid';
const columns = [
    { field: 'id', headerName: 'ID', flex: 0.2},
    { field: 'name', headerName: 'Book title', flex: 1},
    { field: 'totalAmount', headerName: 'Total amount of copies', flex: 1 },
    { 
      field: 'Author',
      headerName: 'Author',
      valueGetter: (params) =>
    `${params.getValue('author')?.firstname || ''} ${
      params.getValue('author')?.lastname || ''
    }`,
    flex: 1
  },
    { 
      field: 'publishYear',
      headerName: 'Publish year',
      valueGetter: (params) =>
    `${new Date(params.getValue('publishYear')).getFullYear()}`,
    flex: 1
   }
  ];
  
export const UserList = () => {
    const [users, setUsers] = useState([]);
    useEffect(
        ()=> {
            axios.get('/api/users');
        }
    ,[]);
    return (
        <Grid columns={columns} data={users}/>
    );
}