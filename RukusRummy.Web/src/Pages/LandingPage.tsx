import { useEffect, useState } from "react"

function Landing() {
  const [response, setResponse] = useState("")

  const fetchUserData = () => {
    fetch(`${process.env.NODE_ENV === "development" ? 'http://localhost:5001' : ''}/api/test`)
      .then(response => {
        return response.text()
      })
      .then(data => {
        setResponse(data)
      })
  }

  useEffect(() => {
  fetchUserData()
  }, [])
  
    return (
      <div className="App">
        <header className="App-header">
          <h1>Landing {response}</h1>
        </header>
      </div>
    );
  }
  
  export default Landing;
  
  