import React, {useState} from 'react';
import { TextField, Button } from '@material-ui/core';
import { MuiPickersUtilsProvider, KeyboardDatePicker} from '@material-ui/pickers';
import DateFnsUtils from '@date-io/date-fns';

export const CreateBookForm = () => {
  const [publishYear, setPublishYear] = useState(new Date().getFullYear());
  const handlePublichYear = (year) => {
    setPublishYear(year);
  }
  return (
    <form>
      <TextField fullWidth name="name" label="Name" type="text" variant="outlined" />
      <TextField  name="amount" label="Amount of copies" type="number" variant="outlined" />
      <MuiPickersUtilsProvider utils={DateFnsUtils}>
      <KeyboardDatePicker
        views={["year"]}
        minDate={'1000-01-01'}
        label="Release year"
        inputVariant="outlined"
        variant="outlined" 
        margin="normal"
        format="yyyy"
        value={publishYear}
        onChange={handlePublichYear}
        KeyboardButtonProps={{
            'aria-label': 'change date',
          }}
        />
        </MuiPickersUtilsProvider>
      <Button fullWidth variant="contained" contained color="primary">Create book</Button>
    </form>
  );
}