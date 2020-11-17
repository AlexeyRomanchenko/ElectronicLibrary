import React, {useState, useEffect} from 'react';
import { TextField, Button } from '@material-ui/core';
import { MuiPickersUtilsProvider, KeyboardDatePicker} from '@material-ui/pickers';
import DateFnsUtils from '@date-io/date-fns';
import { ChipsBlock } from '../../common/chips-block';
import { CreateAuthorForm } from '../create-author-form';
import { CreateGenreForm } from '../create-genre-form';
import { ImageUpload } from '../../image-upload';
import {useForm} from 'react-hook-form';
import axios from 'axios';

export const CreateBookForm = () => {
  useEffect(()=> {
    axios({
      method:'GET',
      url: '/api/author'
    }).then(response=> {
      const _authors = response.data.map(author => {
        return {
          id: author.id,
          label:`${author.firstname} ${author.lastname}`}
      });
      console.log(_authors);
      setAuthors(_authors);
    });

    axios({
      method:'GET',
      url: '/api/Genre'
    }).then(response=> {
      const _genres = response.data.map(genre => {
        return {
          id: genre.id,
          label:`${genre.name}`}
      });
      console.log(_genres);
      setGenres(_genres);
    });

  },[]);
  const [authors, setAuthors] = useState([]);
  const [genres, setGenres] = useState([]);
  const [authorId, setAuthor] = useState(null);
  const [genreId, setGenre] = useState(null);
  const [image, _setImage] = useState(null);
  const { register, handleSubmit, errors } = useForm();
  const [publishYear, setPublishYear] = useState(new Date());

  const handlePublichYear = (year) => {
    setPublishYear(year);
  }
  const setImage = (image) => {
    _setImage(image);
  }
  const selectedAuthor = (author) => {
    setAuthor(author.id);
  }
  const selectedGenre = (genre) => {
    setGenre(genre.id);
  }
  const onSubmit = data => {
    console.log(data, errors);
    var formData = new FormData();
    formData.append("imagePath",image );
    formData.append('name', data.name);
    formData.append('authorId', data.author);
    formData.append('publishYear',`${data.releaseDate}-01-01`);
    formData.append('totalAmount', data.amount);
    formData.append('genreId', data.genre);
    axios({
      method:'POST',
      url:'/api/book',
      headers: new Headers({
        "Content-Type": "multipart/form-data"
      }),
     data: formData
    });
  }
  return (
    <form onSubmit={handleSubmit(onSubmit)}>
      <TextField name="name" label="Name" type="text" variant="outlined" fullWidth inputRef={register({required:true})}/>
      {errors.name && <span>This field is required</span>}     
      <TextField  name="amount" label="Amount of copies" type="number" variant="outlined" inputRef={register({required:true})}/>
      <MuiPickersUtilsProvider utils={DateFnsUtils}>
      <KeyboardDatePicker
        views={["year"]}
        name="releaseDate"
        minDate={'1000-01-01'}
        label="Released year"
        inputVariant="outlined"
        variant="outlined" 
        margin="normal"
        format="yyyy"
        value={publishYear}
        onChange={handlePublichYear}
        inputRef={register({required:true})}
        KeyboardButtonProps={{
            'aria-label': 'change date',
          }}
        />
        </MuiPickersUtilsProvider>
        {errors.releaseDate && <span>This field is required</span>} 
        <ChipsBlock chips={authors} setItem={selectedAuthor} header="Please, select or create a new author for the book" form={CreateAuthorForm}/>
        <input type="hidden" name="author" defaultValue={authorId} ref={register({required: true})}/>
        {errors.author && <span>This field is required!!!!!</span>}     
        <ChipsBlock chips={genres} setItem={selectedGenre} header="Please, select or create a new genre for the book" form={CreateGenreForm}/>
        <input type="hidden" name="genre" defaultValue={authorId} ref={register({required: true})}/>
        {errors.genre && <span>This field is required!!!!!</span>}
        <ImageUpload setImage={setImage}/>
      <Button fullWidth variant="contained" color="primary" type="submit">Create book</Button>
    </form>
  );
}