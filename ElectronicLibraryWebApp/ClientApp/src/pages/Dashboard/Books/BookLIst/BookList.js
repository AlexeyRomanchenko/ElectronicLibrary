import React, {useEffect, useState} from 'react';
import Fab from '@material-ui/core/Fab';
import AddIcon from '@material-ui/icons/Add';
import axios from 'axios';
import {Grid} from '../../../../components/common/grid';
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
  
export const BookList = () => {

    const [books, setBooks] = useState([]);
    useEffect(()=>{
        axios.get('/api/book').then(response =>{
           if(response.status === 200) {
               setBooks(response.data);
           }
        });

    },[]);
    return (
        <>
            <Fab color="primary" aria-label="add">
                <AddIcon />
            </Fab>
            <div>
                <Grid columns = {columns} data = {books}/>
            </div>
        </>
    );
}