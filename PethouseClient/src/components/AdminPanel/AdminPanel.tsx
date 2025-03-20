import { useEffect, useState } from "react";

function AdminPanel() {
  const [data, setData] = useState(null);
  const [loading, setLoading] = useState(true);

  useEffect(() => {
    // Fetch the API
    fetch("http://localhost:8080/api/Pets") // Use service name as hostname
      .then((response) => {
        if (!response.ok) {
          throw new Error("Network response was not ok");
        }
        return response.json();
      })
      .then((data) => {
        setData(data); // Set the fetched data
        setLoading(false); // Turn off loading
      })
      .catch((error) => {
        console.error("There was an error fetching the data:", error);
        setLoading(false);
      });
  }, []);

  if (loading) {
    return <div className="mr-10">Loading...</div>;
  }

  return (
    <div>
      <h1 className="m-10">Reload is working API DATA:</h1>
      <pre className="m-10">{JSON.stringify(data, null, 2)}</pre>
    </div>
  );
}

export default AdminPanel;
