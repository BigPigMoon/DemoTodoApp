import axios from "axios";

export const API_URL = 'http://localhost:5000';

var $api = axios.create({
    withCredentials: true,
    baseURL: API_URL,
});

export default $api;