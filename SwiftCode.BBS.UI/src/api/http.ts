import axios from 'axios'

const service = axios.create({
  baseURL : 'http://localhost:5000/api',
  timeout : 5000
})




export default service
