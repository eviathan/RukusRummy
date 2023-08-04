import { useContext, useEffect, useState } from "react"

import HeroSection from "../Components/Sections/HeroSection"
import { Api } from "../Contexts/ApiContext";

function Landing() {
    
    const [data, setData] = useState<string | undefined>();
    const [loading, setLoading] = useState(true);
    
    const api = useContext(Api);

    useEffect(() => {
        const load = async () => {
            try {
                const result = await api?.test.get();
                setData(result);
                setLoading(false);
            } catch (e) {
                setLoading(false);
            }
        };

        load();
    }, [api]);
  
    return (
      <div className="landing-page">
        {data}
        <HeroSection />
      </div>
    );
  }

  export default Landing;
  
  