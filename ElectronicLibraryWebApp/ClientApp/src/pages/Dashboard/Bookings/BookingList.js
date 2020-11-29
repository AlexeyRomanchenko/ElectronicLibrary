import React, {useEffect, useState} from 'react';
import axios from 'axios';
import { Grid } from '../../../components/common/grid';

const columns = [
    { field: 'id', headerName: 'ID', flex: 0.2},
    { field: 'name', headerName: 'Book title',
    valueGetter: (params) =>
    `${params.getValue('book')?.name || ''}`,
    flex: 1},
    { 
      field: 'User',
      headerName: 'User',
      valueGetter: (params) =>
    `${params.getValue('user')?.userName || ''}`,
    flex: 1
  },
    { 
      field: 'bookingDate',
      headerName: 'Booking date',
      flex: 1
   },
    { 
    field: 'issueDate',
    headerName: 'Issued date',
    flex: 1
 },
 { 
 field: 'status',
 headerName: 'Status',
 flex: 1
}
  ];
  

export const BookingList = () => {
  const [bookings, setBookings] = useState([]);
  useEffect(()=> {
    axios.get('/api/booking')
    .then(response=> {
      if(response.status === 200) {
        console.log(response.data);
        setBookings(response.data);
      }
    });
  },[]);
    return (
        <>
            <Grid columns={columns} data={bookings}/>
        </>
    );
}