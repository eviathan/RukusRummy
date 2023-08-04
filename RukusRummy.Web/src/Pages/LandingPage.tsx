import { useContext, useEffect, useState } from "react"

import HeroSection from "../Components/Sections/HeroSection"
import { Api } from "../Contexts/ApiContext";

function Landing() {
    const api = useContext(Api);

    // NOTE: API USEAGE EXAMPLE
    const [data, setData] = useState<string | undefined>();
    const [loading, setLoading] = useState(true);

    useEffect(() => {
        const load = async () => {
            try {
                const result = await api.deck.getAll();
                setData(JSON.stringify(result, null, 4));
                setLoading(false);
            } catch (e) {
                setLoading(false);
            }
        };

        load();
    }, [api]);
  
    return (
      <div className="landing-page">
        <HeroSection title="Scrum Poker for agile development teams" subTitle={data} />
      </div>
    );
  }

  export default Landing;
  
  