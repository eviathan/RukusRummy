import { useEffect, useState } from "react"
import HeroSection from "../Components/Sections/HeroSection"

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
      <div className="landing-page">
        <HeroSection />
      </div>
    );
  }
  
  export default Landing;
  
  