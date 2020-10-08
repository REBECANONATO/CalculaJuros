import axios from 'axios';

const api = axios.create({
  baseURL: 'https://localhost:44353/'
});

export default api;